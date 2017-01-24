using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.ViewModels;
using BO;

namespace DAL.IRepository
{
    public interface IProductRepository
    {
        int InsertUpdateDesign(VmProduct ObjDesign);

        int InsertUpdateVarient(VmProduct ObjDesign);

        List<Varient> GetVarients(int Id);

        List<Design> GetDesigns();

        VmProduct GetProductById(int DesignId);
    }
}
