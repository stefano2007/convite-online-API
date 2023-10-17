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
        private readonly IMapper _mapper;
        public FotoService(IFotoRepositorio fotoRepositorio, IMapper mapper)
        {
            _fotoRepositorio = fotoRepositorio;
            _mapper = mapper;
        }

        public async Task<FotoDTO> AlterarAsync(FotoAlterarDTO request, CancellationToken cancellation)
        {
            var foto = await _fotoRepositorio.ObterPorIdAsync(request.Id, cancellation);

            if (foto == null)
            {
                throw new Exception("Foto não encontrada para deletar");
            }

            foto.Update(request.AniversarioId, request.Src, request.Titulo, request.SubTitulo, request.Ordem);

            var result = await _fotoRepositorio.AlterarAsync(foto, cancellation);
            return _mapper.Map<FotoDTO>(result);
        }

        public async Task<FotoDTO> CriarAsync(FotoCriarDTO request, CancellationToken cancellation)
        {
            var foto = new Foto(Guid.NewGuid().ToString(), request.AniversarioId, request.Src, request.Titulo, request.SubTitulo, request.Ordem);

            if (foto == null)
            {
                throw new ApplicationException($"Error creating entity.");
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
