import { h } from 'vue';

const gridColumns = [
  { field: 'reportDate' },
  {
    field: 'place',
    cellRenderer: function (params) {
      return `<a href="https://maps.google.com/?q=${params.data.lat},${params.data.lon}" target="_blank">${params.value}</a>`;
    },
  },
  { field: 'category', cellDataType: 'text' },
  {
    headerName: 'Image',
    field: 'image',
    cellRenderer: function (params) {
      return renderImageLink(params.data.imageUrl);
    },
  },
];

const renderImageLink = (imageUrl) => {
  return h(
    'a',
    {
      href: 'javascript:void(0);',
      onClick: () => console.log(imageUrl),
    },
    'View'
  );
};

export { gridColumns };