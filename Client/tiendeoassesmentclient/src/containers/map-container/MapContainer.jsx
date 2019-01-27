import React, { Component } from "react";
import { connect } from "react-redux";
import { loadCityTopStores } from "../../actions/map";
import SelectorComponent from "../../components/selector-component";
class MapContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {
      numberOfStores: 10
    };
  }
  HandleNumberOfStores = ({ target }) => {
    this.setState({ numberOfStores: target.value });
  };
  OnShowClick = () => {
    this.props.loadCityTopStores(this.props.mapsite, this.state.numberOfStores);
  };
  render() {
    return (
      <div className="main-map">
        <h1 className="city-name">{this.props.mapsite}</h1>
        <SelectorComponent
          numberOfStores={this.state.numberOfStores}
          handleTextChange={this.HandleNumberOfStores}
          onShowClick={this.OnShowClick}
        />
      </div>
    );
  }

  componentWillReceiveProps(nextProps) {
    if (nextProps.mapsite !== this.props.mapsite) {
      this.props.loadCityTopStores(
        nextProps.mapsite,
        this.state.numberOfStores
      );
    }
  }
  componentDidMount() {
    this.props.loadCityTopStores(this.props.mapsite, this.state.numberOfStores);
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
