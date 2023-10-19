using AutoMapper;
using ConviteOnline.Application.DTOs;
using ConviteOnline.Application.Interfaces;
using ConviteOnline.Domain.Entities;
using ConviteOnline.Domain.Interfaces;

namespace ConviteOnline.Application.Services
{
    public class FotoService : IFotoService
    {
        private readonly IFotoRepositorio _fotoRepositorio;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
        public FotoService(IFotoRepositorio fotoRepositorio, IMapper mapper, IStorageService storageService)
        {
            _fotoRepositorio = fotoRepositorio;
            _storageService = storageService;
            _mapper = mapper;
        }

        //TODO: verificar aonde será obtido o caminho posteriomente por enquanto fixo
        const string caminhoImagens = @"assets/img/";

        public async Task<FotoDTO> AlterarAsync(FotoAlterarDTO request, CancellationToken cancellation)
        {
            var foto = await _fotoRepositorio.ObterPorIdAsync(request.Id, cancellation);

            if (foto == null)
            {
                throw new Exception("Foto não encontrada para alterar");
            }

            foto.Update(request.AniversarioId, request.Titulo, request.SubTitulo, request.Ordem);

            var result = await _fotoRepositorio.AlterarAsync(foto, cancellation);
            return _mapper.Map<FotoDTO>(result);
        }

        public async Task<FotoDTO> CriarAsync(FotoCriarDTO request, UploadFileDTO file, CancellationToken cancellation)
        {
            //TODO: subir no S3            
            var urlArquivo = await _storageService.CarregaArquivoAsync(file, caminhoImagens, cancellation);

            if (string.IsNullOrEmpty(urlArquivo))
            {
                throw new ApplicationException($"Erro ao salvar arquivo.");
            }

            var foto = new Foto(Guid.NewGuid().ToString(), request.AniversarioId, urlArquivo, request.Titulo, request.SubTitulo, request.Ordem);

            if (foto == null)
            {
                throw new ApplicationException($"Erro na criação da entidade.");
            }

            var result = await _fotoRepositorio.CriarAsync(foto, cancellation);
            return _mapper.Map<FotoDTO>(result);
        }

        public async Task<FotoDTO> DeletaAsync(string id, CancellationToken cancellation)
        {
            var foto = await _fotoRepositorio.ObterPorIdAsync(id, cancellation);

            if(foto == null)
            {
                throw new Exception("Foto não encontrada para deletar");
            }

            //TODO: deletar no S3            
            var removido = await _storageService.DeletarArquivoAsync(foto.Src, cancellation);

            if (!removido)
            {
                throw new ApplicationException($"Erro ao excluir arquivo.");
            }

            var result = await _fotoRepositorio.DeletaAsync(foto, cancellation);

            return _mapper.Map<FotoDTO>(result);
        }

        public async Task<FotoDTO> ObterPorIdAsync(string id, CancellationToken cancellation)
        {
            var result =  await _fotoRepositorio.ObterPorIdAsync(id, cancellation);

            return _mapper.Map<FotoDTO>(result);
        }

        public async Task<IEnumerable<FotoDTO>> ObterPorAniversarioIdAsync(string aniversarioId, CancellationToken cancellation)
        {
            var result = await _fotoRepositorio.ObterPorAniversarioIdAsync(aniversarioId, cancellation);

            return _mapper.Map<IEnumerable<FotoDTO>>(result);
        }
    }
}
