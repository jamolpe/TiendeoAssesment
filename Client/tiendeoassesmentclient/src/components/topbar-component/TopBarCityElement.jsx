import React from "react";

const TopBarCityElement = ({ cityName, active, HandleChangeSite }) => {
  return (
    <span>
      <span className={active ? "active" : ""} onClick={HandleChangeSite}>
        {cityName}
      </span>
    </span>
  );
};

export default React.memo(TopBarCityElement);
