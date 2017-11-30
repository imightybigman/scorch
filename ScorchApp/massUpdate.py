import boto3

dynamodb = boto3.resource('dynamodb')

table = dynamodb.Table('DnD-Items-dev')

response = table.scan(
    ProjectionExpression='#k,#s',
    ExpressionAttributeNames={
        '#k' : 'ItemId',
        '#s' : 'sortkey'
    }
)


items = response['Items']

for item in items:
    response = table.update_item(
        Key=item,
        UpdateExpression='SET #s = :status, #d = :del',
        ExpressionAttributeNames={
            '#s' : 'Purchasable',
            '#d' : 'CampaignId'
        },
        ExpressionAttributeValues={
            ':status' : True,
            ':del'    : '0'
        }

    )
