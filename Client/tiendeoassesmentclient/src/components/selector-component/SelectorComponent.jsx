import React from "react";

const SelectorComponent = ({
  numberOfStores,
  handleTextChange,
  onShowClick
}) => {
  return (
    <div>
      select the number of stores to show:
      <input value={numberOfStores} onChange={handleTextChange} />
      <button onClick={onShowClick}>Show</button>
    </div>
  );
};

export default React.memo(SelectorComponent);
