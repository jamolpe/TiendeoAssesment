import React from "react";

const SelectorComponent = ({
  numberOfStores,
  handleTextChange,
  onShowClick,
  validationError
}) => {
  return (
    <div>
      <label>Select the number of stores to show:</label>
      <input
        type="text"
        className={validationError ? "form-control is-invalid" : "form-control"}
        pattern="[0-9]*"
        value={numberOfStores}
        onChange={handleTextChange}
      />
      <button onClick={onShowClick}>Show</button>
    </div>
  );
};

export default React.memo(SelectorComponent);
