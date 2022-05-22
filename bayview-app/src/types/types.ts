export type ImageInfoType = {
  Id?: number;
  Title: string;
  Description: string;
};

export type ImageType = ImageInfoType & {
  ImageData: any;
};
