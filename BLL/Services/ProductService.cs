using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DAL.IRepository;
using BO.ViewModels;
using BO;

namespace BLL.Services
{
    public class ProductService 
    {
        public IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public int InsertUpdateDesign(VmProduct ObjDesign)
        {
            return _repository.InsertUpdateDesign(ObjDesign);
        }

        public int InsertUpdateVarient(VmProduct ObjDesign)
        {
            return _repository.InsertUpdateVarient(ObjDesign);
        }

        public List<Varient> GetVarients(int Id)
        {
            return _repository.GetVarients(Id);
        }

        public List<Design> GetDesigns()
        {
            return _repository.GetDesigns();
        }

        public VmProduct GetProductById(int DesignId)
        {
            return _repository.GetProductById(DesignId);
        }
    }
}
