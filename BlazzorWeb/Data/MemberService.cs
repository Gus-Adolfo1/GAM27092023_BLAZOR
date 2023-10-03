using member.DTOs.memberDTOs;

namespace BlazzorWeb.Data
{
    public class MemberService
    {
        readonly HttpClient _httpClient;

        public MemberService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BLAZZORAPI");
        }

        public async Task<searchOutputDTO> Search(searchQueryDTO searchQueryMemberDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/member/search", searchQueryMemberDTO);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<searchOutputDTO>();
                return result ?? new searchOutputDTO();
            }
            return new searchOutputDTO();
        }

        public async Task<searchResultDTO> GetById(int id)
        {
            var response = await _httpClient.GetAsync("/member/" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<searchResultDTO>();
                return result ?? new searchResultDTO();
            }

            return new searchResultDTO();
        }

        public async Task<int> Create(createMemberDTO createPersonDTO)
        {
            int result = 0;
            var response = await _httpClient.PostAsJsonAsync("/member", createPersonDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }

            return result;
        }

        public async Task<int> Edit(EditMemberDTO editMemberDTO)
        {
            int result = 0;
            var response = await _httpClient.PostAsJsonAsync("/person", editMemberDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }

            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            var response = await _httpClient.DeleteAsync("/member/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }

            return result;
        }
    }
}
