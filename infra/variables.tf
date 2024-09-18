variable "aws_region" {
  type        = string
  description = "Região que será criado a infra na AWS"
}

variable "aws_profile" {
  type        = string
  description = "Perfil configurado no AWS CLI"
}

variable "environment" {
  type        = string
  description = "Identifica o Ambiente"
}

variable "bucket_name" {
  description = "Nome do bucket S3"
  type = string
  default = "xpto-bucket"
}

variable "table_name" {
  description = "Nome da tabela"
  type = string
  default = "person"
}

variable "table_key" {
  description = "Chave principal da tabela"
  type = string
  default = "id"
}

variable "bucket_name_app" {
  description = "Bucket S3 onde será hospetado o site estatico"
  type = string
}


variable "tags_padrao" {
  description = "Tags padrão"
  type = object({})
}