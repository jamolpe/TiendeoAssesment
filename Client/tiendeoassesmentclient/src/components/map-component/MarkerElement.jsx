import React, { Component } from "react";

export default class MarkerElement extends Component {
  CalculateRankColour = () => {
    var { rank } = this.props;
    if (rank > 0 && rank <= 5) {
      return "green";
    } else if (rank > 5 && rank <= 10) {
      return "orange";
    } else {
      return "red";
    }
  };
  render() {
    var { markerUrl, storeName, businessName, rank } = this.props;
    return (
      <div className="marker-container">
        <img className="img-container" src={markerUrl} alt={storeName} />
        <div className="business-name">
          <span>{businessName}</span>
        </div>
        <div className={this.CalculateRankColour()}>
          <span>Global position: {rank}</span>
        </div>
      </div>
    );
  }
}
