using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using ConviteOnline.Application.DTOs;
using ConviteOnline.Application.Utils.DTOs;
using Microsoft.Extensions.Configuration;

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
            return new AmazonS3ClientUtil(
                RegionEndpoint.GetBySystemName(configuration["aws.region"]), 
                configuration["aws.s3.bucket.name"]
                );
        }

        public async Task<S3ResponseDTO> UploadFileAsync(UploadFileDTO obj, string path, CancellationToken cancellation)
        {
            var response = new S3ResponseDTO();
            try
            {
                path = path.Replace(@"\", "/");
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = obj.Stream,
                    Key = $"{path}/{obj.NewFileName}",
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
            //TODO:
            //   era assim https://stefano.silva.dev-convite-online-storage.s3.sa-east-1.amazonaws.com/
            // agora assim https://s3.sa-east-1.amazonaws.com/stefano.silva.dev-convite-online-storage/
            //return $"https://{BucketNameStorage}.s3.{RegionName}.amazonaws.com/" + keyName;
            return $"https://s3.{RegionName}.amazonaws.com/{BucketNameStorage}/" + keyName;
        }

        //TODO remover SERVER
        private string GetPathByUlrFile(string urlFile)
        {
            //TODO: Revisa metodo para obter caminho do arquivo
            return urlFile.Replace($"https://s3.{RegionName}.amazonaws.com/{BucketNameStorage}/", "");
        }
    }
}
