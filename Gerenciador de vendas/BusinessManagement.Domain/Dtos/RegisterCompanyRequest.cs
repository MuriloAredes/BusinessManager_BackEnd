namespace BusinessManagement.Domain.Dtos
{
    public record RegisterCompanyRequest(string Cnpj,
        string NomeSocial,
        string Estado,
        string Situacao,
        string Descricao);


}
