# Convite Online API

No repositorio no repositorio [Convite Online](https://github.com/stefano2007/convite-online) criei o fontend da aplica��o e nesse ser� criado o backend

- [ ] Deve ter o endpoint aniversarios.
- Campos obrigatorios: Nome, Titulo, Descri��o, Data Aniversario, Data Evento, Horario Evento, Endere�o e Data Limite de Confirma a Presen�a. 
    - [ ] Pode ser marcado at� 6 fotos em destaque.
	- [ ] Pode ser selecionado at� 20 fotos no carrossel.
- [x] Deve ter o endpoint fotos.
    - [x] Upload de imagens no S3
    - [ ] refatorar padr�o CQRS
- [ ] Deve ter o endpoint respostas (Confirma��o de Presen�a).

## Escopo do Projeto

- [ ] Projeto WEB API
    - [ ] .Net 7.
    - [ ] Arquitetura Limpa.
    - [ ] AutoMapper.
    - [ ] MediaR.
    - [ ] Versionamento API exemplo /api/v1/aniversarios.
    - [ ] Testes
- [ ] Configurar na maquina local Acess Key 
    - Acessa o IAM gerar chave de acesso do usuario
    - executar o CLI comando > aws configure [tutorial configura��o CLI](https://youtu.be/Rp-A84oh4G8?si=A6fV60GXeYLafXWX)
- [x] Persistir os dados no DynamoDB da AWS.
    - [x] Cria tabela respostasConviteOnline
    - [x] Cria tabela fotosConviteOnline
    - [x] Cria tabela respostasConviteOnline
- [x] Salvar imagens e videos(opcional) no AWS S3.
    - [x] Criar bucket stefanodev-convite-online-storage para hospedar as imagens e talvez videos.
- [ ] CI / CD.
