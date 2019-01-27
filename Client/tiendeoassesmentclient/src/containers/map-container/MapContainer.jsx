import React, { Component } from "react";
import { connect } from "react-redux";
import { loadCityTopStores } from "../../actions/map";
import SelectorComponent from "../../components/selector-component";
import MapComponent from "../../components/map-component";
class MapContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {
      numberOfStores: 10,
      hasValidationError: false
    };
  }
  HandleNumberOfStores = ({ target }) => {
    this.setState({ numberOfStores: target.value });
    if (!this.CheckIsNumber(target.value)) {
      this.setState({ hasValidationError: true });
    } else {
      this.setState({ hasValidationError: false });
    }
  };
  CheckIsNumber(n) {
    return !isNaN(parseFloat(n)) && !isNaN(n - 0);
  }
  OnShowClick = () => {
    if (!this.state.hasValidationError) {
      this.props.loadCityTopStores(
        this.props.mapsite.name,
        this.state.numberOfStores
      );
    }
  };
  render() {
    var { data } = this.props.mapreducer;
    var { mapsite } = this.props;
    return (
      <div className="main-map">
        {mapsite ? (
          <>
            <h1 className="city-name">{mapsite.name}</h1>
            <SelectorComponent
              numberOfStores={this.state.numberOfStores}
              handleTextChange={this.HandleNumberOfStores}
              validationError={this.state.hasValidationError}
              onShowClick={this.OnShowClick}
            />
          </>
        ) : (
          ""
        )}
        {data ? (
          <MapComponent
            city={mapsite}
            center={{ lat: mapsite.lat, lng: mapsite.lon }}
            stores={data}
          />
        ) : (
          ""
        )}
      </div>
    );
  }

  componentWillReceiveProps(nextProps) {
    if (nextProps.mapsite.name !== this.props.mapsite.name) {
      this.props.loadCityTopStores(
        nextProps.mapsite.name,
        this.state.numberOfStores
      );
    }
  }
  componentDidMount() {
    this.props.loadCityTopStores(
      this.props.mapsite.name,
      this.state.numberOfStores
    );
  }
}
const mapStateToProps = ({ mapreducer }) => ({
  mapreducer
});

const mapDispatchToProps = dispatch => ({
  loadCityTopStores: (cityName, storesCount) =>
    dispatch(loadCityTopStores(cityName, storesCount))
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(MapContainer);
