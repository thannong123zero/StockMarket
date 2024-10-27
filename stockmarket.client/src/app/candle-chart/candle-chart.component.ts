import { Component, OnInit, OnDestroy } from '@angular/core';
import * as am5 from "@amcharts/amcharts5";
import * as am5xy from "@amcharts/amcharts5/xy";
import * as am5stock from "@amcharts/amcharts5/stock";
import am5themes_Animated from "@amcharts/amcharts5/themes/Animated";
import { HttpClient } from '@angular/common/http';
import { publishFacade } from '@angular/compiler';
import { any } from '@amcharts/amcharts5/.internal/core/util/Array';

@Component({
  selector: 'app-candle-chart',
  templateUrl: './candle-chart.component.html',
  styleUrls: ['./candle-chart.component.scss'],
  standalone: true
})
export class CandleChartComponent implements OnInit, OnDestroy {
  private root!: am5.Root;
  public stockHistory: StockHistoryViewModel[] = [];
  constructor(private http: HttpClient) { }


  async ngOnInit(): Promise<void> {
    await this.GetData();
    this.CreateChart();
  }

  ngOnDestroy(): void {
    if (this.root) {
      this.root.dispose();
    }
  }

  GetData(): Promise<void> {
    // this.http.get<StockHistoryViewModel[]>('/api/stockhistory/getall').toPromise().then(
    //   data => {
    //     if(data)
    //      {
    //       data;
    //       console.log("DCM");
    //       console.log(data);
    //      }
    //   },
    //   error => {
    //     console.error(error);
    //   }
    // );

    return this.http.get<StockHistoryViewModel[]>('/api/stockhistory/getall').toPromise().then(
      data => {
        if(data)
         {
          this.stockHistory = data;
          console.log(this.stockHistory);
         }
      },
      error => {
        console.error(error);
      }
    );
  }

  CreateChart(): void{
    //console.log(this.stockHistory);
        // Create root element
        this.root = am5.Root.new("chartdiv");

        // Set themes
        this.root.setThemes([am5themes_Animated.new(this.root)]);
    
        // Create a stock chart
        let stockChart = this.root.container.children.push(am5stock.StockChart.new(this.root, {}));
    
        // Set global number format
        this.root.numberFormatter.set("numberFormat", "#,###.00");
    
        // Create a main stock panel (chart)
        let mainPanel = stockChart.panels.push(am5stock.StockPanel.new(this.root, {
          wheelY: "zoomX",
          panX: true,
          panY: false,
          height: am5.percent(70)
        }));
    
        // Create value axis
        let valueAxis = mainPanel.yAxes.push(am5xy.ValueAxis.new(this.root, {
          renderer: am5xy.AxisRendererY.new(this.root, { pan: "zoom" }),
          extraMin: 0.1,
          tooltip: am5.Tooltip.new(this.root, {}),
          numberFormat: "#,###.00",
          extraTooltipPrecision: 2
        }));
    
        let dateAxis = mainPanel.xAxes.push(am5xy.GaplessDateAxis.new(this.root, {
          baseInterval: { timeUnit: "day", count: 1 },
          renderer: am5xy.AxisRendererX.new(this.root, { minorGridEnabled: true }),
          tooltip: am5.Tooltip.new(this.root, {})
        }));
    
        // Add series
        let valueSeries = mainPanel.series.push(am5xy.CandlestickSeries.new(this.root, {
          name: "MSFT",
          clustered: false,
          valueXField: "date",
          valueYField: "close",
          highValueYField: "high",
          lowValueYField: "low",
          openValueYField: "open",
          calculateAggregates: true,
          xAxis: dateAxis,
          yAxis: valueAxis,
          legendValueText: "open: [bold]{openValueY}[/] high: [bold]{highValueY}[/] low: [bold]{lowValueY}[/] close: [bold]{valueY}[/]",
          legendRangeValueText: ""
        }));

        //set default period 6 months
        var periodSelector = am5stock.PeriodSelector.new(this.root, {
          stockChart: stockChart
        });
        valueSeries.events.once("datavalidated", function() {
          periodSelector.selectPeriod({ timeUnit: "month", count: 6 });
        });

        // Set main value series
        stockChart.set("stockSeries", valueSeries);
    
        // Add a stock legend
        let valueLegend = mainPanel.plotContainer.children.push(am5stock.StockLegend.new(this.root, {
          stockChart: stockChart
        }));
    
        // Create a volume panel (chart)
        let volumePanel = stockChart.panels.push(am5stock.StockPanel.new(this.root, {
          panX: true,
          panY: true,
          height: am5.percent(30),
          paddingTop: 6
        }));
    
        // Hide close button
        volumePanel.panelControls.closeButton.set("forceHidden", true);
    
        let volumeDateAxis = volumePanel.xAxes.push(am5xy.GaplessDateAxis.new(this.root, {
          baseInterval: { timeUnit: "day", count: 1 },
          renderer: am5xy.AxisRendererX.new(this.root, { minorGridEnabled: true }),
          tooltip: am5.Tooltip.new(this.root, { forceHidden: true }),
          height: 0
        }));
    
        volumeDateAxis.get("renderer").labels.template.set("forceHidden", true);
    
        // Create volume axis
        let volumeAxisRenderer = am5xy.AxisRendererY.new(this.root, {});
        let volumeValueAxis = volumePanel.yAxes.push(am5xy.ValueAxis.new(this.root, {
          numberFormat: "#.#a",
          renderer: volumeAxisRenderer
        }));
    
        // Add series
        let volumeSeries = volumePanel.series.push(am5xy.ColumnSeries.new(this.root, {
          name: "Volume",
          clustered: false,
          valueXField: "date",
          valueYField: "volume",
          xAxis: volumeDateAxis,
          yAxis: volumeValueAxis,
          legendValueText: "[bold]{valueY.formatNumber('#,###.0a')}[/]"
        }));
    
        volumeSeries.columns.template.setAll({
          strokeOpacity: 0,
          fillOpacity: 0.5
        });
    
        volumeSeries.columns.template.adapters.add("fill", function(fill, target) {
          let dataItem = target.dataItem;
          if (dataItem) {
            return stockChart.getVolumeColor(dataItem);
          }
          return fill;
        });
    
        // Add a stock legend
        let volumeLegend = volumePanel.plotContainer.children.push(am5stock.StockLegend.new(this.root, {
          stockChart: stockChart
        }));
    
        // Set main series
        stockChart.set("volumeSeries", volumeSeries);
        valueLegend.data.setAll([valueSeries]);
        volumeLegend.data.setAll([volumeSeries]);
    
        // Add cursors
        mainPanel.set("cursor", am5xy.XYCursor.new(this.root, {
          yAxis: valueAxis,
          xAxis: dateAxis,
          snapToSeries: [valueSeries],
          snapToSeriesBy: "y!"
        }));
    
        let volumeCursor = volumePanel.set("cursor", am5xy.XYCursor.new(this.root, {
          yAxis: volumeValueAxis,
          xAxis: volumeDateAxis,
          snapToSeries: [volumeSeries],
          snapToSeriesBy: "y!"
        }));
    
        volumeCursor.lineY.set("forceHidden", true);
    
        // Add scrollbar
        let scrollbar = mainPanel.set("scrollbarX", am5xy.XYChartScrollbar.new(this.root, {
          orientation: "horizontal",
          height: 50
        }));
        stockChart.toolsContainer.children.push(scrollbar);
    
        let sbDateAxis = scrollbar.chart.xAxes.push(am5xy.GaplessDateAxis.new(this.root, {
          baseInterval: { timeUnit: "day", count: 1 },
          renderer: am5xy.AxisRendererX.new(this.root, {})
        }));
    
        let sbValueAxis = scrollbar.chart.yAxes.push(am5xy.ValueAxis.new(this.root, {
          renderer: am5xy.AxisRendererY.new(this.root, {})
        }));
    
        let sbSeries = scrollbar.chart.series.push(am5xy.LineSeries.new(this.root, {
          valueYField: "close",
          valueXField: "date",
          xAxis: sbDateAxis,
          yAxis: sbValueAxis
        }));
    
        sbSeries.fills.template.setAll({
          visible: true,
          fillOpacity: 0.3
        });
    
        // Set up series type switcher
        let seriesSwitcher = am5stock.SeriesTypeControl.new(this.root, {
          stockChart: stockChart
        });
    
        seriesSwitcher.events.on("selected", function(ev:any) {
          setSeriesType(ev.item.id);
        });
    
        const getNewSettings = (series: am5xy.XYSeries) => {
          let newSettings: any = [];
          am5.array.each(["name", "valueYField", "highValueYField", "lowValueYField", "openValueYField", "calculateAggregates", "valueXField", "xAxis", "yAxis", "legendValueText", "legendRangeValueText", "stroke", "fill"], function(setting: any) {
            newSettings[setting] = series.get(setting);
          });
          return newSettings;
        };
    
        const setSeriesType = (seriesType: string) => {
          let currentSeries = stockChart.get("stockSeries")!;
          let newSettings = getNewSettings(currentSeries);
    
          let data = currentSeries.data.values;
          mainPanel.series.removeValue(currentSeries);
    
          let series;
          switch (seriesType) {
            case "line":
              series = mainPanel.series.push(am5xy.LineSeries.new(this.root, newSettings));
              break;
            case "candlestick":
            case "procandlestick":
              newSettings.clustered = false;
              series = mainPanel.series.push(am5xy.CandlestickSeries.new(this.root, newSettings));
              if (seriesType == "procandlestick") {
                series.columns.template.get("themeTags")!.push("pro");
              }
              break;
            case "ohlc":
              newSettings.clustered = false;
              series = mainPanel.series.push(am5xy.OHLCSeries.new(this.root, newSettings));
              break;
          }
    
          if (series) {
            valueLegend.data.removeValue(currentSeries);
            series.data.setAll(data);
            stockChart.set("stockSeries", series);
            let cursor = mainPanel.get("cursor");
            if (cursor) {
              cursor.set("snapToSeries", [series]);
            }
            valueLegend.data.insertIndex(0, series);
          }
        };
    
        // Stock toolbar
        let toolbar = am5stock.StockToolbar.new(this.root, {
          container: document.getElementById("chartcontrols")!,
          stockChart: stockChart,
          controls: [
            am5stock.IndicatorControl.new(this.root, { stockChart: stockChart, legend: valueLegend }),
            am5stock.DateRangeSelector.new(this.root, { stockChart: stockChart }),
            am5stock.PeriodSelector.new(this.root, { stockChart: stockChart}),
            seriesSwitcher,
            am5stock.DrawingControl.new(this.root, { stockChart: stockChart }),
            am5stock.ResetControl.new(this.root, { stockChart: stockChart }),
            am5stock.SettingsControl.new(this.root, { stockChart: stockChart })
          ]
        });
        // Add bollinger bands
        stockChart.indicators.push(am5stock.BollingerBands.new(this.root, {
          stockChart: stockChart,
          stockSeries: valueSeries,
          legend: valueLegend,
          type: "simple"
        }));

      // Add Volume Profile indicator
      stockChart.indicators.push(am5stock.VolumeProfile.new(this.root, {
        stockChart: stockChart,
        stockSeries: valueSeries,
        volumeSeries: volumeSeries,
        legend: valueLegend
      }));
        // add indicator
      stockChart.indicators.push(am5stock.RelativeStrengthIndex.new(this.root, { stockChart: stockChart, stockSeries: valueSeries }));

        // Set data to all series
        valueSeries.data.setAll(this.stockHistory);
        volumeSeries.data.setAll(this.stockHistory);
        sbSeries.data.setAll(this.stockHistory);

  }
}

interface StockHistoryViewModel {
  Date: number;
  Open: number;
  High: number;
  Low: number;
  Close: number;
  Volume: number;
}