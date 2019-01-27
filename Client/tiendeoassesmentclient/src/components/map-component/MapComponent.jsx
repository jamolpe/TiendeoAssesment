import React, { Component } from "react";
import GoogleMapReact from "google-map-react";
import { googleKey } from "../../Config";
import MarkerElement from "./MarkerElement";
class MapComponent extends Component {
  render() {
    var { stores } = this.props;
    return (
      <div className="map-container" style={{ height: "100vh", width: "100%" }}>
        <GoogleMapReact
          bootstrapURLKeys={{ key: googleKey }}
          center={this.props.center}
          defaultZoom={14}
        >
          {stores.map((store, i) => {
            var { name, marker } = store.business;
            return (
              <MarkerElement
                key={i}
                storeName={store.name}
                markerUrl={marker}
                businessName={name}
                rank={store.rank}
                lat={store.lat}
                lng={store.lon}
              />
            );
          })}
        </GoogleMapReact>
      </div>
    );
  }
}

export default React.memo(MapComponent);
