export const gridColumns = [
  { field: 'reportDate' },
  {
    field: 'place',
    cellRenderer: function (params) {
      return `<a href="https://maps.google.com/?q=${params.data.lat},${params.data.lon}" target="_blank">${params.value}</a>`
    },
  },
  { field: 'category', cellDataType: 'text' },
  { field: 'condition', cellDataType: 'text' },
  {
    headerName: 'Image',
    field: 'image',
    cellRenderer: function (params) {
      console.log(params.data.imageThumbUrl);
      if (!params.data.imageThumbUrl) {
        return 'N/A';
      }
      return `<a href="${params.data.imageUrl}" target="_blank">View</a>`;
    },
  },
]
