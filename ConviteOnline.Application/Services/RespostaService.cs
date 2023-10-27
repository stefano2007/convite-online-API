using AutoMapper;
using ConviteOnline.Application.DTOs;
using ConviteOnline.Application.Interfaces;
using ConviteOnline.Domain.Entities;
using ConviteOnline.Domain.Interfaces;

namespace ConviteOnline.Application.Services
{
    public class RespostaService : IRespostaService
    {
        private readonly IRespostaRepositorio _respostaRepositorio;
        private readonly IMapper _mapper;
        public RespostaService(IRespostaRepositorio respostaRepositorio, IMapper mapper)
        {
            _respostaRepositorio = respostaRepositorio;
            _mapper = mapper;
        }

        public async Task<RespostaDTO> AlterarAsync(RespostaAlterarDTO request, CancellationToken cancellation)
        {
            var resposta = await _respostaRepositorio.ObterPorIdAsync(request.Id, cancellation);

            if (resposta == null)
            {
                throw new ApplicationException("Resposta não encontrada para alterar");
            }

            resposta.Update(request.AniversarioId, request.QtdAdultos, request.QtdCriancas, request.Mensagem, request.MarcaPresenca, DateTime.Now);

            var result = await _respostaRepositorio.AlterarAsync(resposta, cancellation);
            return _mapper.Map<RespostaDTO>(result);
        }

        public async Task<RespostaDTO> CriarAsync(RespostaCriarDTO request, CancellationToken cancellation)
        {
            var resposta = new Resposta(Guid.NewGuid().ToString(), request.AniversarioId, request.QtdAdultos, request.QtdCriancas, request.Mensagem,request.MarcaPresenca, DateTime.Now, null);

            if (resposta == null)
            {
                throw new ApplicationException($"Erro na criação da entidade.");
            }

            var result = await _respostaRepositorio.CriarAsync(resposta, cancellation);
            return _mapper.Map<RespostaDTO>(result);
        }

        public async Task<RespostaDTO> DeletaAsync(string id, CancellationToken cancellation)
        {
            var resposta = await _respostaRepositorio.ObterPorIdAsync(id, cancellation);

            if (resposta == null)
            {
                throw new ApplicationException("Resposta não encontrada para deletar");
            }

            var result = await _respostaRepositorio.DeletaAsync(resposta, cancellation);

            return _mapper.Map<RespostaDTO>(result);
        }

        public async Task<RespostaDTO> ObterPorIdAsync(string id, CancellationToken cancellation)
        {
            var result = await _respostaRepositorio.ObterPorIdAsync(id, cancellation);

            return _mapper.Map<RespostaDTO>(result);
        }

        public async Task<IEnumerable<RespostaDTO>> ObterPorAniversarioIdAsync(string aniversarioId, CancellationToken cancellation)
        {
            var result = await _respostaRepositorio.ObterPorAniversarioIdAsync(aniversarioId, cancellation);

            return _mapper.Map<IEnumerable<RespostaDTO>>(result);
        }
    }
}
