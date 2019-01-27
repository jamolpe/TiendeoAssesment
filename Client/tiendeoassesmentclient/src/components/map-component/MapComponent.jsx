import React, { Component } from "react";
import GoogleMapReact from "google-map-react";
import { googleKey } from "../../Config";
export default class MapComponent extends Component {
  render() {
    return (
      <div className="map-container" style={{ height: "100vh", width: "100%" }}>
        <GoogleMapReact
          bootstrapURLKeys={{ key: googleKey }}
          center={this.props.center}
          defaultZoom={14}
        />
      </div>
    );
  }
}
