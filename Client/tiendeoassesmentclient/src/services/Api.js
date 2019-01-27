export const LoadCityServices = city => {
  return fetch(
    "http://localhost:5001/api/Service/GetAllServicesFromACity/" + city,
    {
      method: "GET"
    }
  ).then(response => {
    if (response.status === 200) {
      return response.json();
    } else {
      return response.statusText;
    }
  });
};

export const LoadTopStoresFromCity = (city, number) => {
  return fetch(
    "http://localhost:5001/api/Store/GetTopXFromCityStoresOrderByRank/" +
      city +
      "/" +
      number,
    {
      method: "GET"
    }
  ).then(response => {
    if (response.status === 200) {
      return response.json();
    } else {
      return response.statusText;
    }
  });
};
