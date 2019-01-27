import React, { Component } from "react";
import TopBarComponent from "../../components/topbar-component";
import MapContainer from "../map-container";

export default class MainContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {
      mapsite: "Barcelona"
    };
  }
  ChangeSite = site => {
    this.setState({ mapsite: site });
  };
  render() {
    return (
      <div>
        <TopBarComponent
          active={this.state.mapsite}
          ChangeSite={this.ChangeSite}
        />
        <div className="main-body">
          <MapContainer mapsite={this.state.mapsite} />
        </div>
      </div>
    );
  }
}
