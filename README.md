# Convite Online API

No repositorio no repositorio [Convite Online](https://github.com/stefano2007/convite-online) criei o fontend da aplicação e nesse será criado o backend

- [x] Deve ter o endpoint aniversarios.
- Campos obrigatorios: Nome, Titulo, Descrição, Data Aniversario, Data Evento, Horario Evento, Endereço e Data Limite de Confirma a Presença. 
    - [x] Pode ser marcado até 6 fotos em destaque.
	- [x] Pode ser selecionado até 20 fotos no carrossel.
- [x] Deve ter o endpoint fotos.
    - [x] Upload de imagens no S3
    - [ ] refatorar padrão CQRS
- [x] Deve ter o endpoint respostas (Confirmação de Presença).

## Escopo do Projeto

- [x] Projeto WEB API
    - [x] .Net 7.
    - [x] Arquitetura Limpa.
    - [x] AutoMapper.
    - [ ] MediaR.
    - [x] Versionamento API exemplo /api/v1/aniversarios.
    - [ ] Testes
- [x] Configurar na maquina local Acess Key 
    - Acessa o IAM gerar chave de acesso do usuario
    - executar o CLI comando > aws configure [tutorial configuração CLI](https://youtu.be/Rp-A84oh4G8?si=A6fV60GXeYLafXWX)
- [x] Persistir os dados no DynamoDB da AWS.
    - [x] Cria tabela aniversariosConviteOnline
    - [x] Cria tabela fotosConviteOnline
    - [x] Cria tabela respostasConviteOnline
- [x] Salvar imagens e videos(opcional) no AWS S3.
    - [x] Criar bucket stefanodev-convite-online-storage para hospedar as imagens e talvez videos.
- [ ] CI / CD.
