resource "aws_s3_bucket" "app" {
  bucket = "${var.bucket_name_app}-${var.environment}"

  tags = var.tags_padrao
}

resource "aws_s3_bucket" "repositorio" {
  bucket = "${var.bucket_name}-${var.environment}"

  tags = var.tags_padrao
}