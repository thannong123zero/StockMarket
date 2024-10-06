import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ChartComponent } from './chart/chart.component';
import { CandleChartComponent } from './candle-chart/candle-chart.component';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  standalone: true,
  imports: [CandleChartComponent]
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {

  }

  title = 'stockmarket.client';
}
