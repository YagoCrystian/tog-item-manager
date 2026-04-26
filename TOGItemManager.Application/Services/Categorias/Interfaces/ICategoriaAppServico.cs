using TOGItemManager.Application.DTOs.Categorias.Requests;
using TOGItemManager.Application.DTOs.Categorias.Responses;
using TOGItemManager.Application.DTOs.Comuns.Responses;

namespace TOGItemManager.Application.Services.Categorias.Interfaces
{
    public interface ICategoriaAppServico
    {
        void Inserir(CategoriaInserirRequest request);
        void Atualizar(CategoriaAtualizarRequest request);
        void Remover(int id);
        CategoriaResponse ObterPorId(int id);
        PaginacaoResponse<CategoriaResponse> Query(CategoriaFiltrarRequest filtro);

    }
}