import {
  LOAD_CITYTOPSTORES_REQUEST,
  LOAD_CITYTOPSTORES_SUCESS,
  LOAD_CITYTOPSTORES_FAIL
} from "../actions/map";

const initialState = { loading: false, data: [], haserror: false };

export default (state = initialState, { type, payload }) => {
  switch (type) {
    case LOAD_CITYTOPSTORES_REQUEST:
      return {
        loading: true
      };
    case LOAD_CITYTOPSTORES_SUCESS:
      return {
        haserror: false,
        loading: false,
        data: payload
      };
    case LOAD_CITYTOPSTORES_FAIL:
      return {
        loading: false,
        haserror: true
      };
    default:
      return state;
  }
};
