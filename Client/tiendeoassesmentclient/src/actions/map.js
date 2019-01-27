import * as Api from "../services/Api";

export const LOAD_CITYTOPSTORES_REQUEST =
  "[Load_Stores] LOAD_CITYTOPSTORES_REQUEST";
export const LOAD_CITYTOPSTORES_SUCESS =
  "[Load_Stores] LOAD_CITYTOPSTORES_SUCESS";
export const LOAD_CITYTOPSTORES_FAIL = "[Load_Stores] LOAD_CITYTOPSTORES_FAIL";

export const loadCityTopStores = (cityName, storesCount) => {
  return async dispatch => {
    dispatch({
      type: LOAD_CITYTOPSTORES_REQUEST
    });
    await Api.LoadTopStoresFromCity(cityName, storesCount).then(
      result => {
        if (result) {
          dispatch({
            type: LOAD_CITYTOPSTORES_SUCESS,
            payload: result
          });
        } else {
          dispatch({
            type: LOAD_CITYTOPSTORES_FAIL
          });
        }
      },
      error => {
        dispatch({
          type: LOAD_CITYTOPSTORES_FAIL,
          payload: error.toString()
        });
      }
    );
  };
};
