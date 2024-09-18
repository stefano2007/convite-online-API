#terraform plan -var-file="./envs/dev/terraform.tfvars"
#terraform apply -var-file="./envs/dev/terraform.tfvars" -auto-approve
#terraform destroy -var-file="./envs/dev/terraform.tfvars" -auto-approve
terraform {
  required_version = "1.8.4"

  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "5.51.1"
    }

  }

  backend "s3" {
    bucket  = "stefanodev-tfstate"
    key     = "teste/terraform.tfstate"
    region  = "sa-east-1"
    profile = "default"
    endpoint = "http://s3.localhost.localstack.cloud:4566"
  }
}

provider "aws" {
  access_key                  = "test"
  secret_key                  = "test"
  region                      = "sa-east-1"
  s3_use_path_style           = false
  skip_credentials_validation = true
  skip_metadata_api_check     = true
  skip_requesting_account_id  = true

  endpoints {
    apigateway     = "http://localhost:4566"
    apigatewayv2   = "http://localhost:4566"
    cloudformation = "http://localhost:4566"
    cloudwatch     = "http://localhost:4566"
    dynamodb       = "http://localhost:4566"
    ec2            = "http://localhost:4566"
    es             = "http://localhost:4566"
    elasticache    = "http://localhost:4566"
    firehose       = "http://localhost:4566"
    iam            = "http://localhost:4566"
    kinesis        = "http://localhost:4566"
    lambda         = "http://localhost:4566"
    rds            = "http://localhost:4566"
    redshift       = "http://localhost:4566"
    route53        = "http://localhost:4566"
    s3             = "http://s3.localhost.localstack.cloud:4566"
    secretsmanager = "http://localhost:4566"
    ses            = "http://localhost:4566"
    sns            = "http://localhost:4566"
    sqs            = "http://localhost:4566"
    ssm            = "http://localhost:4566"
    stepfunctions  = "http://localhost:4566"
    sts            = "http://localhost:4566"
  }
}

