import { Component, inject, OnInit } from '@angular/core';
import { LocationEnum } from '../../models/location.enum.model';
import { CommonModule } from '@angular/common';
import { Solicitor } from '../../models/solicitor.model';
import { SolicitorService } from '../../services/solicitor.service';

@Component({
  selector: 'app-search',
  imports: [CommonModule],
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss',
})
export class SearchComponent {
  locationOptions = Object.values(LocationEnum);
  private solicitorService = inject(SolicitorService);
  selectedLocation: string = '';

  solicitors: Solicitor[] = [];

  onSearch(location: string) {
    this.solicitorService.searchByLocation(location)
      .subscribe(results => this.solicitors = results);
  }
}

