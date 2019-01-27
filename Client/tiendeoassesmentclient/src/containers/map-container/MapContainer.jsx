import React, { Component } from "react";
import { connect } from "react-redux";
import { loadCityTopStores } from "../../actions/map";
class MapContainer extends Component {
  render() {
    return <div>mostrando {this.props.mapsite}</div>;
  }

  componentWillReceiveProps(nextProps) {
    if (nextProps.mapsite !== this.props.mapsite) {
      this.props.loadCityTopStores(nextProps.mapsite, 10);
    }
  }
  componentDidMount() {
    this.props.loadCityTopStores(this.props.mapsite, 10);
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
