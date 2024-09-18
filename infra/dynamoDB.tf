provider "aws" {
  alias  = "sa-east-1"
  region = "sa-east-1"
}

resource "aws_dynamodb_table" "aniversario" {
  provider = aws.sa-east-1

  hash_key         = "id"
  name             = "aniversariosConviteOnline"
  stream_enabled   = true
  stream_view_type = "NEW_AND_OLD_IMAGES"
  read_capacity    = 1
  write_capacity   = 1

  attribute {
    name = var.table_key
    type = "S"
  }
}

resource "aws_dynamodb_table" "foto" {
  provider = aws.sa-east-1

  hash_key         = "id"
  name             = "fotosConviteOnline"
  stream_enabled   = true
  stream_view_type = "NEW_AND_OLD_IMAGES"
  read_capacity    = 1
  write_capacity   = 1

  attribute {
    name = var.table_key
    type = "S"
  }
}

resource "aws_dynamodb_table" "resposta" {
  provider = aws.sa-east-1

  hash_key         = "id"
  name             = "respostasConviteOnline"
  stream_enabled   = true
  stream_view_type = "NEW_AND_OLD_IMAGES"
  read_capacity    = 1
  write_capacity   = 1

  attribute {
    name = var.table_key
    type = "S"
  }
}