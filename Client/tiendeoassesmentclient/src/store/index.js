import { createStore, applyMiddleware, compose } from "redux";
import thunk from "redux-thunk";

import rootReducer from "../reducers";
import logger from "./middlewares/logger";
const composEnhancers = window.__REDUX_DEVTOOLS_EXENSION_COMPOSE__ || compose;
const middlewares = [thunk];

if (process.env.NODE_ENV !== "production") {
  middlewares.push(logger);
}
const store = createStore(
  rootReducer,
  composEnhancers(applyMiddleware(...middlewares))
);

export default store;
