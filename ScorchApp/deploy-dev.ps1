npm run build-dev
aws s3 sync dist/ s3://dnd-app-dev
