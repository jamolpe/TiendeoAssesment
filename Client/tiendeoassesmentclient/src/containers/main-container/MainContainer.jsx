import React, { Component } from "react";
import TopBarComponent from "../../components/topbar-component";
import MapComponent from "../../components/map-component";

export default class MainContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {
      mapsite: "Barcelona"
    };
  }
  ChangeSite = site => {
    console.log("lanzado" + site);
    this.setState({ mapsite: site });
  };
  render() {
    return (
      <div>
        <TopBarComponent ChangeSite={this.ChangeSite} />
        <div className="main-body">
          <MapComponent mapsite={this.state.mapsite} />
        </div>
      </div>
    );
  }
}
