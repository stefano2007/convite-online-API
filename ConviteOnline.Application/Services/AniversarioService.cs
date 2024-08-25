using AutoMapper;
using ConviteOnline.Application.DTOs;
using ConviteOnline.Application.Interfaces;
using ConviteOnline.Domain.Entities;
using ConviteOnline.Domain.Interfaces;

namespace ConviteOnline.Application.Services
{
    public class AniversarioService : IAniversarioService
    {
        private readonly IAniversarioRepositorio _aniversarioRepositorio;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
        public AniversarioService(IAniversarioRepositorio aniversarioRepositorio, IMapper mapper, IStorageService storageService)
        {
            _aniversarioRepositorio = aniversarioRepositorio;
            _storageService = storageService;
            _mapper = mapper;
        }
        public async Task<FotoDTO> AdicionarFotoCarrosselAsync(FotoCriarDTO request, UploadFileDTO file, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioRepositorio.ObterPorIdAsync(request.AniversarioId, cancellation);

            if (aniversario == null)
            {
                throw new ApplicationException("Aniversario não encontrada para alterar");
            }
            // TODO: subir no S3
            var urlArquivo = await _storageService.CarregaArquivoAsync(file, request.AniversarioId, "fotosCarrossel", cancellation);

            if (string.IsNullOrEmpty(urlArquivo))
            {
                throw new ApplicationException($"Erro ao salvar arquivo.");
            }

            var foto = new Foto(file.NewId, request.AniversarioId, urlArquivo, request.Titulo, request.SubTitulo, request.Ordem);

            await _aniversarioRepositorio.AdicionarFotoCarrosselAsync(foto, cancellation);
            return _mapper.Map<FotoDTO>(foto);
        }

        public async Task<FotoDTO> AdicionarFotoDestaqueAsync(FotoCriarDTO request, UploadFileDTO file, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioRepositorio.ObterPorIdAsync(request.AniversarioId, cancellation);

            if (aniversario == null)
            {
                throw new ApplicationException("Aniversario não encontrada para alterar");
            }

            // TODO: subir no S3
            var urlArquivo = await _storageService.CarregaArquivoAsync(file, request.AniversarioId, "fotosDestaque", cancellation);

            if (string.IsNullOrEmpty(urlArquivo))
            {
                throw new ApplicationException($"Erro ao salvar arquivo.");
            }            

            var foto = new Foto(file.NewId, request.AniversarioId, urlArquivo, request.Titulo, request.SubTitulo, request.Ordem);

            await _aniversarioRepositorio.AdicionarFotoDestaqueAsync(foto, cancellation);
            return _mapper.Map<FotoDTO>(foto);
        }

        public async Task<AniversarioDTO> AlterarAsync(AniversarioAlterarDTO request, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioRepositorio.ObterPorIdAsync(request.Id, cancellation);

            if (aniversario == null)
            {
                throw new ApplicationException("Aniversario não encontrada para alterar");
            }

            aniversario.Update(request.Slug, request.Nome, request.Idade, request.Descricao, request.Titulo, request.Informativos,
                request.DataAniversario, request.DataEvento, request.HorarioEvento, request.Local, request.Endereco, request.LocalizacaoUrl,
                request.DataLimiteConfirmaPresenca);

            var result = await _aniversarioRepositorio.AlterarAsync(aniversario, cancellation);
            return _mapper.Map<AniversarioDTO>(result);
        }

        public async Task<AniversarioDTO> AlterarImagemConviteAsync(string aniversarioId, UploadFileDTO file, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioRepositorio.ObterPorIdAsync(aniversarioId, cancellation);

            if (aniversario == null)
            {
                throw new ApplicationException("Aniversario não encontrada para alterar");
            }

            // TODO: subir no S3
            var urlArquivo = await _storageService.CarregaArquivoAsync(file, aniversarioId, "convite", cancellation);

            if (string.IsNullOrEmpty(urlArquivo))
            {
                throw new ApplicationException($"Erro ao salvar arquivo.");
            }

            aniversario.AlterarImagemConvite(urlArquivo);

            var result = await _aniversarioRepositorio.AlterarAsync(aniversario, cancellation);
            return _mapper.Map<AniversarioDTO>(result);
        }

        public async Task<AniversarioDTO> CriarAsync(AniversarioCriarDTO request, CancellationToken cancellation)
        {
            var aniversario = new Aniversario(Guid.NewGuid().ToString(),request.Slug, request.Nome, request.Idade, request.Descricao, request.Titulo, request.Informativos,
                request.DataAniversario, request.DataEvento, request.HorarioEvento, request.Local, request.Endereco, request.LocalizacaoUrl,
                request.DataLimiteConfirmaPresenca);

            if (aniversario == null)
            {
                throw new ApplicationException($"Erro na criação da entidade.");
            }

            var result = await _aniversarioRepositorio.CriarAsync(aniversario, cancellation);
            return _mapper.Map<AniversarioDTO>(result);
        }

        public async Task<AniversarioDTO> DeletaAsync(string id, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioRepositorio.ObterPorIdAsync(id, cancellation);

            if (aniversario == null)
            {
                throw new ApplicationException("Aniversario não encontrada para deletar");
            }

            var result = await _aniversarioRepositorio.DeletaAsync(aniversario, cancellation);

            return _mapper.Map<AniversarioDTO>(result);
        }

        public async Task<AniversarioDTO> ObterPorIdAsync(string id, CancellationToken cancellation)
        {
            var result = await _aniversarioRepositorio.ObterPorIdAsync(id, cancellation);

            return _mapper.Map<AniversarioDTO>(result);
        }

        public async Task<AniversarioDTO> ObterPorSlugAsync(string slug, CancellationToken cancellation)
        {
            var result = await _aniversarioRepositorio.ObterPorSlugAsync(slug, cancellation);

            return _mapper.Map<AniversarioDTO>(result);
        }

        public async Task<FotoDTO> RemoverFotoCarrosselAsync(string id, string aniversarioId, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioRepositorio.ObterPorIdAsync(aniversarioId, cancellation);

            if (aniversario == null)
                throw new ApplicationException("Aniversario não encontrada para alterar.");

            var foto = aniversario.FotosCarrossel?.Where(x => x.Id == id).FirstOrDefault();

            if (foto == null)
                throw new ApplicationException("Foto não encontrada para excluir.");

            //TODO: deletar no S3            
            var removido = await _storageService.DeletarArquivoAsync(foto.Src, cancellation);

            if (!removido)
                throw new ApplicationException($"Erro ao excluir arquivo.");

            aniversario.RemoverFotoCarrossel(foto);

            await _aniversarioRepositorio.AlterarAsync(aniversario, cancellation);
            return _mapper.Map<FotoDTO>(foto);
        }

        public async Task<FotoDTO> RemoverFotoDestaqueAsync(string id, string aniversarioId, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioRepositorio.ObterPorIdAsync(aniversarioId, cancellation);

            if (aniversario == null)
                throw new ApplicationException("Aniversario não encontrada para alterar.");

            var foto = aniversario.FotosDestaque?.Where(x => x.Id == id).FirstOrDefault();

            if (foto == null)
                throw new ApplicationException("Foto não encontrada para excluir.");

            //TODO: deletar no S3            
            var removido = await _storageService.DeletarArquivoAsync(foto.Src, cancellation);

            if (!removido)
                throw new ApplicationException($"Erro ao excluir arquivo.");

            aniversario.RemoverFotoDestaque(foto);

            await _aniversarioRepositorio.AlterarAsync(aniversario, cancellation);
            return _mapper.Map<FotoDTO>(foto);
        }

        public async Task<AniversarioDTO> RemoverImagemConviteAsync(string id, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioRepositorio.ObterPorIdAsync(id, cancellation);

            if (aniversario == null)
            {
                throw new ApplicationException("Aniversario não encontrada para alterar");
            }

            if (!string.IsNullOrEmpty(aniversario.ImagemConvite))
            {
                //TODO: deletar no S3            
                var removido = await _storageService.DeletarArquivoAsync(aniversario.ImagemConvite, cancellation);

                if (!removido)
                    throw new ApplicationException($"Erro ao excluir arquivo.");
            }

            aniversario.RemoverImagemConvite();

            var result = await _aniversarioRepositorio.AlterarAsync(aniversario, cancellation);
            return _mapper.Map<AniversarioDTO>(result);
        }
    }
}
