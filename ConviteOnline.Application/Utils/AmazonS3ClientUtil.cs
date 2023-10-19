using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using ConviteOnline.Application.DTOs;
using ConviteOnline.Application.Utils.DTOs;
using Microsoft.Extensions.Configuration;
using System;

namespace ConviteOnline.Application.Utils
{
    public class AmazonS3ClientUtil : AmazonS3Client
    {
        public readonly string BucketNameStorage;
        public readonly string RegionName;
        private AmazonS3ClientUtil(RegionEndpoint bucketRegion, string bucketName) : base(bucketRegion)
        {
            BucketNameStorage = bucketName;
            RegionName = bucketRegion.SystemName;
        }

        public static AmazonS3ClientUtil IniciarlizacaoS3(IConfiguration configuration)
        {
            var region = RegionEndpoint.GetBySystemName(configuration["AWS:Region"]);
            return new AmazonS3ClientUtil(region, configuration["S3:BucketName"]);
        }

        public async Task<S3ResponseDTO> UploadFileAsync(UploadFileDTO obj, string path, CancellationToken cancellation)
        {
            var response = new S3ResponseDTO();
            try
            {
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = obj.Stream,
                    Key = $"{path}{obj.NewFileName}",
                    BucketName = BucketNameStorage,
                    CannedACL = S3CannedACL.NoACL
                };

                // initialise the transfer/upload tools
                var transferUtility = new TransferUtility(this);

                // initiate the file upload
                await transferUtility.UploadAsync(uploadRequest, cancellation);

                response.StatusCode = 201;
                response.Message = $"{obj.FileName} has been uploaded sucessfully";
                response.UrlResult = MountUrl(uploadRequest.Key);
            }
            catch (AmazonS3Exception s3Ex)
            {
                response.StatusCode = (int)s3Ex.StatusCode;
                response.Message = s3Ex.Message;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<S3ResponseDTO> DeleteFileAsync(string urlFile, CancellationToken cancellation)
        {
            var response = new S3ResponseDTO();
            try
            {
                DeleteObjectRequest request = new DeleteObjectRequest
                {
                    BucketName = BucketNameStorage,
                    Key = GetPathByUlrFile(urlFile)
                };

                /*if (!string.IsNullOrEmpty(versionId))
                    request.VersionId = versionId;*/

                await DeleteObjectAsync(request, cancellation);

                response.StatusCode = 200;
                response.Message = $"file deleted sucessfully";
            }
            catch (AmazonS3Exception s3Ex)
            {
                response.StatusCode = (int)s3Ex.StatusCode;
                response.Message = s3Ex.Message;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            return response;
        }

        private string MountUrl(string keyName)
        {
            return $"https://{BucketNameStorage}.s3.{RegionName}.amazonaws.com/" + keyName;
        }

        private string GetPathByUlrFile(string urlFile)
        {
            //TODO: Revisa metodo para obter caminho do arquivo
            return urlFile.Replace($"https://{BucketNameStorage}.s3.{RegionName}.amazonaws.com/", "");
        }
    }
}
