import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandleChartComponent } from './candle-chart.component';

describe('CandleChartComponent', () => {
  let component: CandleChartComponent;
  let fixture: ComponentFixture<CandleChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CandleChartComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CandleChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
