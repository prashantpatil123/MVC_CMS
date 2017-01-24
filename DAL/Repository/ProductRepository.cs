using BO;
using BO.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DAL.IRepository;

namespace DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        public int InsertUpdateDesign(VmProduct objDesign)
        {
            int DesignId = 0;

            using (IDbConnection con = new SqlConnection(Common.ConnectionString))
            {
                DesignId = con.Query<int>("InsertUpdateDesign",
                new
                {
                    DesignId = objDesign.design.DesignId,
                    ProductCode = objDesign.design.ProductCode,
                    Title = objDesign.design.Title,
                    Description = objDesign.design.Description,
                    ImageUrl = objDesign.design.ImageUrl
                }
                    , commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return DesignId;
        }

        public int InsertUpdateVarient(VmProduct objDesign)
        {
            int ItemId = 0;

            using (IDbConnection con = new SqlConnection(Common.ConnectionString))
            {
                ItemId = con.Query<int>("InsertUpdateVarient",
                new
                {
                    ItemId = objDesign.varient.ItemId,
                    DesignId = objDesign.design.DesignId,
                    SKU = objDesign.varient.SKU,
                    Quantity = objDesign.varient.Quantity,
                    Price = objDesign.varient.Price,
                    Color = objDesign.varient.Color,
                    Size = objDesign.varient.Size
                }
                    , commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return ItemId;
        }

        public List<Varient> GetVarients(int Id)
        {
            using (IDbConnection con = new SqlConnection(Common.ConnectionString))
            {
                string SqlString = "Select ItemId,SKU,Quantity,Price,SizeName,ColorName,I.Color,I.Size from Item I INNER JOIN Color C ON I.Color = C.ColorId INNER JOIN Size S ON I.Size = S.SizeId  where DesignId = " + Id;

                List<Varient> varients = new List<Varient>();

                return con.Query<Varient>(SqlString).ToList();
            }
        }

        public List<Design> GetDesigns()
        {
            using (IDbConnection con = new SqlConnection(Common.ConnectionString))
            {
                string SqlString = "Select * from Design";

                List<Varient> varients = new List<Varient>();

                return con.Query<Design>(SqlString).ToList();
            }
        }

        public VmProduct GetProductById(int DesignId)
        {
            VmProduct ObjDesign = new VmProduct();

            using (IDbConnection con = new SqlConnection(Common.ConnectionString))
            {
                string Sql = "Select * from Design where DesignId = " + DesignId;

                Sql = Sql + " " + "Select ItemId,SKU,Quantity,Price,SizeName,ColorName,I.Color,I.Size from Item I INNER JOIN Color C ON I.Color = C.ColorId INNER JOIN Size S ON I.Size = S.SizeId  where DesignId = " + DesignId;

                using (var multi = con.QueryMultiple(Sql, null, commandType: CommandType.Text))
                {
                    List<Varient> varients = new List<Varient>();
                    ObjDesign.design = multi.Read<Design>().FirstOrDefault();
                 //   ObjDesign.varientList = multi.Read<Varient>().ToList();
                }
            }

            return ObjDesign;
        }
    }
}
