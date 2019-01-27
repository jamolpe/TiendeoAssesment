import {
  LOAD_CITIES_REQUEST,
  LOAD_CITIES_SUCESS,
  LOAD_CITIES_FAIL
} from "../actions/city";

const initialState = { loading: false, data: [], haserror: false };

export default (state = initialState, { type, payload }) => {
  switch (type) {
    case LOAD_CITIES_REQUEST:
      return {
        loading: true
      };
    case LOAD_CITIES_SUCESS:
      return {
        haserror: false,
        loading: false,
        data: payload
      };
    case LOAD_CITIES_FAIL:
      return {
        loading: false,
        haserror: true
      };
    default:
      return state;
  }
};
