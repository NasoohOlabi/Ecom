using DB.IRepos;
using DB.Models;
using DB.UOW;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repos
{
    public class AttachmentRepo : BaseRepo<AttachmentRepo,Attachment>, IAttachmentRepo
    {
        public AttachmentRepo(EComContext db, ILogger<AttachmentRepo> logger) : base(db,logger)
        {
        }
    }
}
