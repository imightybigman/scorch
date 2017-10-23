Param(
    [string] $distributionId
)

npm run build
aws s3 sync dist/ s3://dnd-app.imightybigman.com
aws cloudfront create-invalidation --distribution-id $distributionId --paths /*