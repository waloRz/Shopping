using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shopping.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync();

        Task<IEnumerable<SelectListItem>> GetComboCountriesAsync();

        Task<IEnumerable<SelectListItem>> GetComboStatesAsync(int countryId); //me devuelve las provincia del id Pais

        Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId);

    }
}
