import React, { Component } from "react";

export default class TopBarComponent extends Component {
  HandleChangeSite = site => {
    this.props.ChangeSite(site);
    console.log(site);
  };
  render() {
    return (
      <div className="top-bar">
        <span>
          <a onClick={() => this.HandleChangeSite("Barcelona")}>Barcelona</a>
        </span>
        <span>
          <a
            href="javascript:void(0)"
            onClick={() => this.HandleChangeSite("Madrid")}
          >
            Madrid
          </a>
        </span>
      </div>
    );
  }
}
