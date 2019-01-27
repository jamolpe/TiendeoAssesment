import React, { Component } from "react";

export default class TopBarComponent extends Component {
  HandleChangeSite = site => {
    this.props.ChangeSite(site);
  };
  render() {
    return (
      <div className="top-bar">
        <span>
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
        </span>
      </div>
    );
  }
}
