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
}

function getRenderer({
  targetSelector
  , targetElementsSelector
  , modelToTargetData
  , targetDataIdentity
  , targetElementGenerator
  , targetSelectionCustomizer
  , sourceSelector
  , sourceElementsSelector
  , modelToSourceData
  , sourceDataIdentity
  , sourceElementGenerator
  , sourceSelectionCustomizer
}) {
  return () => {
    const targetSelection = d3.select(targetSelector)
      .selectAll(targetElementsSelector)
      .data(modelToTargetData(Model), targetDataIdentity);
    targetSelection
      .enter()
      .append(targetElementGenerator);
    targetSelection
      .exit().remove();
    targetSelectionCustomizer(targetSelection);
    const sourceSelection = d3.select(sourceSelector)
      .selectAll(sourceElementsSelector)
      .data(modelToSourceData(Model), sourceDataIdentity);
    sourceSelection
      .enter()
      .append(sourceElementGenerator);
    sourceSelection
      .exit().remove();
    sourceSelectionCustomizer(sourceSelection);
  }
}