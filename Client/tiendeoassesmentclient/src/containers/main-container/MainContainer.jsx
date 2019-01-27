import React, { Component } from "react";
import TopBarComponent from "../../components/topbar-component";
import MapContainer from "../map-container";
import { loadCities } from "../../actions/city";
import { connect } from "react-redux";

class MainContainer extends Component {
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
    var { data } = this.props.citiesreducer;
    return (
      <div>
        <TopBarComponent
          cities={data}
          active={this.state.mapsite}
          ChangeSite={this.ChangeSite}
        />
        <div className="main-body">
          <MapContainer mapsite={this.state.mapsite} />
        </div>
      </div>
    );
  }
  componentWillMount() {
    this.props.loadCities();
  }
}
const mapStateToProps = ({ citiesreducer }) => ({
  citiesreducer
});

const mapDispatchToProps = dispatch => ({
  loadCities: () => dispatch(loadCities())
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(MainContainer);
