// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function htmlDecode(input) {
  var doc = new DOMParser().parseFromString(input, "text/html");
  return doc.documentElement.textContent;
}

function getElementFromString(string) {
  let div = document.createElement("div");
  div.innerHTML = string;
  return div.firstElementChild;
}

function parseModel(str) {
  window.Model = JSON.parse(htmlDecode(str))
  console.log(Model)
}

Array.prototype.removeValue = function (value,reducer = (x=>x.Id)) {
  for (let i = 0; i < this.length; i++) {
    if (reducer(this[i]) == value) {
      this.splice(i, 1);
      break;
    } 
  }
};

function getRenderer({
  targetSelector
  , targetElementsSelector
  , modelToTargetData
  , targetDataIdentity
  , targetElementGenerator
  , targetSelectionCustomizer
  , targetEnterSelectionCustomizer
  , sourceSelector
  , sourceElementsSelector
  , modelToSourceData
  , sourceDataIdentity
  , sourceElementGenerator
  , sourceSelectionCustomizer
  , sourceEnterSelectionCustomizer
}) {
  return () => {
    const targetSelection = d3.select(targetSelector)
      .selectAll(targetElementsSelector)
      .data(modelToTargetData(Model), targetDataIdentity);
    const targetEnterSelection = targetSelection
      .enter()
      .append(targetElementGenerator);
    if (targetEnterSelectionCustomizer) targetEnterSelectionCustomizer(targetEnterSelection)
    if (targetSelectionCustomizer) targetSelectionCustomizer(targetSelection);
    targetSelection
      .exit().remove();
    const sourceSelection = d3.select(sourceSelector)
      .selectAll(sourceElementsSelector)
      .data(modelToSourceData(Model), sourceDataIdentity);
    const sourceEnterSelection = sourceSelection
      .enter()
      .append(sourceElementGenerator);
    if (sourceEnterSelectionCustomizer) sourceEnterSelectionCustomizer(sourceEnterSelection)
    if (sourceSelectionCustomizer) sourceSelectionCustomizer(sourceSelection);
    sourceSelection
      .exit().remove();
  }
}