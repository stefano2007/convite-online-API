using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConviteOnline.Infra.Data.Context
{
    public class ApplicationDbContext : DynamoDBContext
    {
        public ApplicationDbContext(IAmazonDynamoDB client) : base(client)
        {
        }
    }
}
