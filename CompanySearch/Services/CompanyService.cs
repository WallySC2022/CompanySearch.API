using CompanySearch.Models;
using CompanySearch.Repositories;

namespace CompanySearch.Services
{
    public class CompanyService
    {
        public void ConsultarEmpresa()
        {
            try
            {
                CompanyRepository companyRepository = new CompanyRepository();
                companyRepository.ConsultarEmpresa();
            }
            catch (Exception exception)
            {
                throw exception;
            }          
        }
        public void CriarEmpresa(Company company)
        {
            try
            {
                CompanyRepository companyRepository = new CompanyRepository();
                companyRepository.CriarEmpresa(company);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void AtualizarEmpresa(Company company)
        {
            try
            {
                CompanyRepository companyRepository = new CompanyRepository();
                companyRepository.AtualizarEmpresa(company);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void DeletarEmpresa(Company company)
        {
            try
            {
                CompanyRepository companyRepository = new CompanyRepository();
                companyRepository.DeletarEmpresa(company);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
