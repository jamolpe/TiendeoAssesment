import { combineReducers } from "redux";
import mapreducer from "./map-reducer";
import citiesreducer from "./cities-reducer";

export default combineReducers({
  mapreducer,
  citiesreducer
});
