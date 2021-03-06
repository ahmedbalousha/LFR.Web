am4core.ready(function() {

// Themes begin
am4core.useTheme(am4themes_animated);
// Themes end


var VDSLchart = am4core.create("vdsl", am4charts.XYChart);
    VDSLchart.dataSource.url = "http://localhost:12849/CMS/Dashboard/GetUsersDashBoardVDSL"
//chart.data = [{
// "type": "New",
// "number": 205
//}, {
// "type": "Active",
// "number": 12
//}, {
// "type": "Non-Active",
// "number": 50
//}, {
// "type": "Restore",
// "number": 2
//}, {
// "type": "Missed",
// "number": 22
//}, {
// "type": "Free",
// "number": 10
//}];

    VDSLchart.padding(10, 0, 30, 0);
    VDSLchart.colors.list = [
  am4core.color("#00c5dc"),
  am4core.color("#845EC2"),
  am4core.color("#f4516c"),
  am4core.color("#FF9671"),
  am4core.color("#FFC75F")
];

    var categoryAxis = VDSLchart.xAxes.push(new am4charts.CategoryAxis());
categoryAxis.renderer.grid.template.location = 0;
categoryAxis.dataFields.category = "type";
categoryAxis.renderer.minGridDistance = 50;
categoryAxis.renderer.inversed = true;
categoryAxis.renderer.grid.template.disabled = true;

    var valueAxis = VDSLchart.yAxes.push(new am4charts.ValueAxis());
valueAxis.min = 0;
valueAxis.extraMax = 0.1;
//valueAxis.rangeChangeEasing = am4core.ease.linear;
//valueAxis.rangeChangeDuration = 1500;

    var series = VDSLchart.series.push(new am4charts.ColumnSeries());
series.dataFields.categoryX = "type";
series.dataFields.valueY = "number";
series.tooltipText = "{valueY.value}"
series.columns.template.strokeOpacity = 0;
series.columns.template.column.cornerRadiusTopRight = 10;
series.columns.template.column.cornerRadiusTopLeft = 10;

//series.interpolationDuration = 1500;
//series.interpolationEasing = am4core.ease.linear;
var labelBullet = series.bullets.push(new am4charts.LabelBullet());
labelBullet.label.verticalCenter = "bottom";
labelBullet.label.dy = -10;
labelBullet.label.fontSize = 18;
labelBullet.label.fontWeight= 700;
labelBullet.label.text = "{values.valueY.workingValue.formatNumber('#.')}";
    VDSLchart.zoomOutButton.disabled = true;

// as by default columns of the same series are of the same color, we add adapter which takes colors from chart.colors color set
series.columns.template.adapter.add("fill", function (fill, target) {
    return VDSLchart.colors.getIndex(target.dataItem.index);
});

setInterval(function () {
 am4core.array.each(chart.data, function (item) {
   item.number += Math.round(Math.random() * 200 - 100);
   item.number = Math.abs(item.number);
 })
 chart.invalidateRawData();
}, 2000)

categoryAxis.sortBySeries = series;

}); // end am4core.ready()