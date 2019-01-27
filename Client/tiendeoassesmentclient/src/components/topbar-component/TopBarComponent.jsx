import React, { Component } from "react";
import TopBarCityElement from "./TopBarCityElement";

export default class TopBarComponent extends Component {
  HandleChangeSite = site => {
    this.props.ChangeSite(site);
  };
  render() {
    var { cities } = this.props;
    return (
      <div className="top-bar">
        {cities
          ? cities.map((city, i) => {
              return (
                <TopBarCityElement
                  key={i}
                  active={this.props.active === city.name ? true : false}
                  cityName={city.name}
                  HandleChangeSite={() => this.HandleChangeSite(city)}
                />
              );
            })
          : ""}
        {/* <span>
          <span
            className={this.props.active === "Barcelona" ? "active" : ""}
            onClick={() => this.HandleChangeSite("Barcelona")}
          >
            Barcelona
          </span>
        </span>
        <span>
          <span
            className={this.props.active === "Madrid" ? "active" : ""}
            onClick={() => this.HandleChangeSite("Madrid")}
          >
            Madrid
          </span>
        </span> */}
      </div>
    );
  }
}
