using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymCenter.Core.Domain.Abstract;
using GymCenter.Core.Domain.Entities;

namespace GymCenter.Core.DataAccess.SqlSever
{
    public class SqlPackageServiceRepository : SqlRepositoryBase<PackageService>, IPackageServiceRepository
    {
        public SqlPackageServiceRepository(string connectionString) : base(connectionString)
        {
        }

        public override void Add(PackageService entity)
        {
            using(var con = SqlConnection)
            {
                var cmd = new SqlCommand("insert into PackageServices output inserted.ID values(@packageId,@serviceId)", con);

                cmd.Parameters.AddWithValue("packageId", entity.Package.Id);
                cmd.Parameters.AddWithValue("serviceId", entity.Service.Id);

                entity.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Delete(PackageService packageService)
        {
            using(var con = SqlConnection)
            {
                var cmd = new SqlCommand("delete from PackageServices where packageId = @packageId and serviceId = @serviceId", con);

                cmd.Parameters.AddWithValue("packageId", packageService.Package.Id);
                cmd.Parameters.AddWithValue("serviceId", packageService.Service.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public override PackageService Get(int id)
        {
            throw new NotImplementedException();
        }

        public override List<PackageService> Get()
        {
            throw new NotImplementedException();
        }

        public List<PackageService> GetByPackageId(int packageId)
        {
            using(var con = SqlConnection)
            {
                var cmd = new SqlCommand("select * from PackageServices where PackageId = @packageId", con);

                cmd.Parameters.AddWithValue("packageId", packageId);

                var reader = cmd.ExecuteReader();

                var list = new List<PackageService>();

                while(reader.Read())
                {
                    var pkgServic = GetFromReader(reader);

                    list.Add(pkgServic);
                }

                return list;
            }
        }

        public List<PackageService> GetByServiceId(int serviceId)
        {
            throw new NotImplementedException();
        }

        public override void Update(PackageService entity)
        {
            throw new NotImplementedException();
        }


        private  PackageService GetFromReader(SqlDataReader reader)
        {
            var pkgService = new PackageService
            {
                Id = Convert.ToInt32(reader["Id"]),
                Package = new Package
                {
                    Id = Convert.ToInt32(reader["PackageId"])
                },

                Service = new Service
                {
                    Id = Convert.ToInt32(reader["ServiceId"])
                }
            };

            return pkgService;
        }
    }
}
