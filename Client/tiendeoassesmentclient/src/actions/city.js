import * as Api from "../services/Api";

export const LOAD_CITIES_REQUEST = "[Load_Cities] LOAD_CITIES_REQUEST";
export const LOAD_CITIES_SUCESS = "[Load_Cities] LOAD_CITIES_SUCESS";
export const LOAD_CITIES_FAIL = "[Load_Cities] LOAD_CITIES_FAIL";

export const loadCities = () => {
  return async dispatch => {
    dispatch({
      type: LOAD_CITIES_REQUEST
    });
    await Api.LoadCities().then(
      result => {
        if (result) {
          dispatch({
            type: LOAD_CITIES_SUCESS,
            payload: result
          });
        } else {
          dispatch({
            type: LOAD_CITIES_FAIL
          });
        }
      },
      error => {
        dispatch({
          type: LOAD_CITIES_FAIL,
          payload: error.toString()
        });
      }
    );
  };
};
