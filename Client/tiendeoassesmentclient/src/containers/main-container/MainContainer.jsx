import React, { Component } from "react";
import TopBarComponent from "../../components/topbar-component";
import MapContainer from "../map-container";
import { loadCities } from "../../actions/city";
import { connect } from "react-redux";

class MainContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {
      mapsite: null
    };
  }
  ChangeSite = site => {
    this.setState({ mapsite: site });
  };
  render() {
    var { data } = this.props.citiesreducer;
    return (
      <div>
        {this.state.mapsite ? (
          <>
            <TopBarComponent
              cities={data}
              active={this.state.mapsite.name}
              ChangeSite={this.ChangeSite}
            />
            <div className="main-body">
              <MapContainer mapsite={this.state.mapsite} cities={data} />
            </div>
          </>
        ) : (
          ""
        )}
      </div>
    );
  }
  componentWillMount() {
    this.props.loadCities();
  }
  componentWillReceiveProps(nextProps) {
    if (nextProps.citiesreducer.data && nextProps.citiesreducer.data !== []) {
      this.ChangeSite(
        nextProps.citiesreducer.data.find(x => x.name === "Barcelona")
      );
    }
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
